namespace StorybaseApi.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {

        //Register the user
        app.MapPost(EndpointStrings.RegisterUser, async Task<Results<Ok<LoginResponse>, BadRequest<LoginResponse>>> (AppDbContext context
            , IPasswordHasher passwordHasher
            , IJwtGenerator jwtGenerator
            , RegisterUserDto registerUser) =>
        {
            if (await context.Users.AnyAsync(u => u.PhoneNumber == registerUser.PhoneNumber))
            {
                return TypedResults.BadRequest(new LoginResponse()
                {
                    Message = "User already exists",
                    Token = null
                });
            }

            var user = new StorybaseUser
            {
                UserName = registerUser.UserName,
                PhoneNumber = registerUser.PhoneNumber
            };

            user.PasswordHash = passwordHasher.HashPassword(registerUser.Password);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return TypedResults.Ok(new LoginResponse()
            {
                Message = "new_user",
                Token = null
            });
        });

        //Login the user
        app.MapPost(EndpointStrings.LoginUser, async Task<Results<Ok<LoginResponse>, BadRequest<LoginResponse>>> (AppDbContext context,
            IPasswordHasher passwordHasher,
            IJwtGenerator tokenService,
            LoginUserRequest loginUser) =>
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == loginUser.PhoneNumber);

                if (user == null || !passwordHasher.VerifyHashedPassword(user.PasswordHash, loginUser.Password))
                {
                    return TypedResults.BadRequest(new LoginResponse() 
                    {
                        Message = "Invalid login credentials",
                        Token = null,
                    });
                }

                var token = tokenService.GenerateToken(user.UserGuid, user.UserName, user.PhoneNumber, user.Role, "your_very_secret_key_here!@#$%^&*()", 30);

                return TypedResults.Ok(new LoginResponse()
                {
                    Message = "Login successful",
                    Token = token
                });
            });

        return app;
    }
}
