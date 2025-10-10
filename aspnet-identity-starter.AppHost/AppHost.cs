var builder = DistributedApplication.CreateBuilder(args);

var usersDb = builder.AddPostgres("database")
  .WithLifetime(ContainerLifetime.Persistent)
  .WithHostPort(5432)
  .AddDatabase("users-db");

var apiService = builder.AddProject<Projects.aspnet_identity_starter_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(usersDb)
    .WaitFor(usersDb);

builder.Build().Run();
