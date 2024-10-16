
using Domain.Ports;
using Moq;
using System.Linq.Expressions;

namespace TestProject.Domain.Ports;

[TestFixture]
public class IGenericRepositoryTests
{
    private Mock<IGenericRepository<EntityBase>> _mockRepository;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IGenericRepository<EntityBase>>();
    }

    [Test]
    public async Task AddAsync_WithValidEntity_ReturnsTrue()
    {
        EntityBase entityToAdd = new();

        _mockRepository.Setup(repo => repo.AddAsync(entityToAdd))
                       .ReturnsAsync(true);

        var result = await _mockRepository.Object.AddAsync(entityToAdd);
        Assert.That(result, Is.True);
        _mockRepository.Verify(repo => repo.AddAsync(entityToAdd), Times.Once);
    }

    [Test]
    public async Task AddAsync_WithValidEntity_ReturnsFalse()
    {
        EntityBase entityToAdd = new();

        _mockRepository.Setup(repo => repo.AddAsync(entityToAdd))
                       .ReturnsAsync(false);

        var result = await _mockRepository.Object.AddAsync(entityToAdd);

        Assert.That(result, Is.False);
        _mockRepository.Verify(repo => repo.AddAsync(entityToAdd), Times.Once);
    }


    [Test]
    public async Task UpdateAsync_WithValidEntity_ReturnsTrue()
    {
        EntityBase entityToUpdate = new();

        _mockRepository.Setup(repo => repo.UpdateAsync(entityToUpdate))
                       .ReturnsAsync(true);

        var result = await _mockRepository.Object.UpdateAsync(entityToUpdate);
        Assert.That(result, Is.True);
        _mockRepository.Verify(repo => repo.UpdateAsync(entityToUpdate), Times.Once);
    }

    [Test]
    public async Task UpdateAsync_WithValidEntity_ReturnsFalse()
    {
        EntityBase entityToUpdate = new();

        _mockRepository.Setup(repo => repo.UpdateAsync(entityToUpdate))
                       .ReturnsAsync(false);

        var result = await _mockRepository.Object.UpdateAsync(entityToUpdate);

        Assert.That(result, Is.False);
        _mockRepository.Verify(repo => repo.UpdateAsync(entityToUpdate), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_WithValidEntity_ReturnsTrue()
    {
        Guid id = new();

        _mockRepository.Setup(repo => repo.DeleteAsync(id))
                       .ReturnsAsync(true);

        var result = await _mockRepository.Object.DeleteAsync(id);
        Assert.That(result, Is.True);
        _mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_WithValidEntity_ReturnsFalse()
    {
        Guid id = new();

        _mockRepository.Setup(repo => repo.DeleteAsync(id))
                       .ReturnsAsync(false);

        var result = await _mockRepository.Object.DeleteAsync(id);
        Assert.That(result, Is.False);
        _mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
    }

    [Test]
    public async Task GetByIdAsync_WithValidId_ReturnsEntity()
    {
        Guid entityId = Guid.NewGuid();
        EntityBase expectedEntity = new() { Id = entityId };

        _mockRepository.Setup(repo => repo.GetByIdAsync(entityId))
                       .ReturnsAsync(expectedEntity);

        var result = await _mockRepository.Object.GetByIdAsync(entityId);


        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(entityId));
        _mockRepository.Verify(repo => repo.GetByIdAsync(entityId), Times.Once);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllEntities()
    {

        List<EntityBase> expectedEntities = [
                new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
            ];

        _mockRepository.Setup(repo => repo.GetAllAsync())
                       .ReturnsAsync(expectedEntities);

        var result = await _mockRepository.Object.GetAllAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(expectedEntities.Count));
        _mockRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }


    [Test]
    public async Task GetByFilterAsync_WithValidFilter_ReturnsEntity()
    {
        Guid entityId = Guid.NewGuid();
        EntityBase filterEntity = new (){ Id = entityId }; 
        EntityBase expectedEntity = new (){ Id = entityId }; 

        _mockRepository.Setup(repo => repo.GetByFilterAsync(filterEntity))
                       .ReturnsAsync(expectedEntity);

        var result = await _mockRepository.Object.GetByFilterAsync(filterEntity);


        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(filterEntity.Id));
        _mockRepository.Verify(repo => repo.GetByFilterAsync(filterEntity), Times.Once);
    }

    [Test]
    public async Task GetAllFilterAsync_ReturnsAllFilterEntities()
    {
        Guid entityId = Guid.NewGuid();
        EntityBase filterEntity = new() { Id = entityId };

        List<EntityBase> expectedEntities = [
                new () { Id = entityId },
                new () { Id = entityId },
                new () { Id = entityId }
            ];

        _mockRepository.Setup(repo => repo.GetAllFilterAsync(filterEntity))
                       .ReturnsAsync(expectedEntities);

        var result = await _mockRepository.Object.GetAllFilterAsync(filterEntity);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(expectedEntities.Count));
        _mockRepository.Verify(repo => repo.GetAllFilterAsync(filterEntity), Times.Once);
    }

    [Test]
    public async Task GetFilterAll_WithValidFilter_ReturnsFilteredEntities()
    {
        Expression<Func<EntityBase, bool>> filter = e => e.Id == Guid.NewGuid();

        List<EntityBase> expectedEntities = [
                new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() },
            new() { Id = Guid.NewGuid() }
        ];

        _mockRepository.Setup(repo => repo.GetFilterAll(filter))
                       .ReturnsAsync(expectedEntities);

        var result = await _mockRepository.Object.GetFilterAll(filter);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(expectedEntities.Count));
        _mockRepository.Verify(repo => repo.GetFilterAll(filter), Times.Once);
    }

    [Test]
    public async Task GetFilter_WithValidFilter_ReturnsFilteredEntity()
    {
        Expression<Func<EntityBase, bool>> filter = e => e.Id == Guid.NewGuid();

        EntityBase expectedEntity = new() { Id = Guid.NewGuid() };

        _mockRepository.Setup(repo => repo.GetFilter(filter))
                       .ReturnsAsync(expectedEntity);

        var result = await _mockRepository.Object.GetFilter(filter);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedEntity));
        _mockRepository.Verify(repo => repo.GetFilter(filter), Times.Once);
    }

    [Test]
    public async Task GetQueryAll_WithValidQuery_ReturnsEntities()
    {
        string query = "SELECT * FROM Entities"; 
        List<EntityBase> expectedEntities = [
            new () { Id = Guid.NewGuid() },
            new () { Id = Guid.NewGuid() }

        ];

        _mockRepository.Setup(repo => repo.GetQueryAll(It.IsAny<string>()))
                       .ReturnsAsync(expectedEntities); 

        var result = await _mockRepository.Object.GetQueryAll(query);


        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(expectedEntities.Count));

        _mockRepository.Verify(repo => repo.GetQueryAll(query), Times.Once);
    }

    [Test]
    public async Task GetQuery_WithValidQuery_ReturnsEntity()
    {
        string query = "SELECT TOP 1 * FROM Entities WHERE Id = @Id";
        EntityBase expectedEntity = new () { Id = Guid.NewGuid()};

        _mockRepository.Setup(repo => repo.GetQuery(It.IsAny<string>()))
                       .ReturnsAsync(expectedEntity); // Simulate returning the expected entity

        var result = await _mockRepository.Object.GetQuery(query);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(expectedEntity.Id));
        _mockRepository.Verify(repo => repo.GetQuery(query), Times.Once);
    }

}
