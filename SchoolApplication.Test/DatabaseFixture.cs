using SchoolApplication.Persistance;
using Xunit;

namespace SchoolApplication.Test;

public class DatabaseFixture : IDisposable
{
    public TestDataBuilder Builder { get; set; }
    public SchoolDbContext SchoolDbContext { get; set; }
    
    public DatabaseFixture()
    {
        SchoolDbContext = new SchoolDbContext();
        Builder = new TestDataBuilder(SchoolDbContext);
        
        SchoolDbContext.Database.EnsureCreated();
        
        // We clear the data from the previously run test
        Builder.CleanDatabase();
        
        // And create the seed data to prepare for out own tests
        Builder.SeedDefaultData();
    }

    public void Dispose()
    { }
}

[CollectionDefinition(TestVariables.DatabaseCollection)]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}