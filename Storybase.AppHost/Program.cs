var builder = DistributedApplication.CreateBuilder(args);

var storybaseapi = builder.AddProject<Projects.StorybaseApi>("storybaseapi");

builder.AddProject<Projects.Storybase_Blazor>("storybase-blazor").WithReference(storybaseapi);

builder.Build().Run();
