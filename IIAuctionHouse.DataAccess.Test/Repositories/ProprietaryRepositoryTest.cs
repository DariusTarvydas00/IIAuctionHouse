using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.Domain.IRepositories;
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class ProprietaryRepositoryTest
    {
          // Checking if ProprietaryRepository is Interface of Proprietary Repository
        [Fact]
        public void ProprietaryRepository_IsIProprietaryRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            Assert.IsAssignableFrom<IProprietaryRepository>(repository);
        }
        
        // Checking if Proprietary Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void ProprietaryRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProprietaryRepository(null));
        }
        
        // Checking if Proprietary Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void ProprietaryRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new ProprietaryRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns Proprietary entities as list of Proprietaryes
        [Fact]
        public void GetAll_GetAllProprietaryEntitiesInDbContext_ReturnsListOfProprietaryes()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var list = new List<ProprietaryEntity>()
            {
                new ProprietaryEntity()
                {
                    Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
                },
                new ProprietaryEntity()
                {
                    Id = 2, CadastreNumber = "321/012:123", ForestryEnterprise = "VardeForestry", City = "Varde"
                },
                new ProprietaryEntity()
                {
                    Id = 3, CadastreNumber = "321/321:321", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
                }
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(ae => new Proprietary()
            {
                Id = ae.Id, CadastreNumber = ae.CadastreNumber, ForestryEnterprise = ae.ForestryEnterprise, City = ae.City
            }).ToList();
 
            var actual = repository.ReadAll();
            Assert.Equal(expectedList, actual, new Comparer());
        }
        
        // Checks if GetById Returns selected ProprietaryEntity as Object
        [Fact]
        public void GetById_Int_ReturnsProprietaryObject()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var list = new List<ProprietaryEntity>()
            {
                new ProprietaryEntity()
                {
                    Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
                },
                new ProprietaryEntity()
                {
                    Id = 2, CadastreNumber = "123/123:123", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
                }
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var ProprietaryEntity = list.Select(ae => new ProprietaryEntity()
            {
                Id = ae.Id,
                CadastreNumber = ae.CadastreNumber,
                ForestryEnterprise = ae.ForestryEnterprise,
                City = ae.City
            }).FirstOrDefault();
            var expectedProprietary = new Proprietary()
            {
                Id = ProprietaryEntity.Id,
                CadastreNumber = ProprietaryEntity.CadastreNumber,
                ForestryEnterprise = ProprietaryEntity.ForestryEnterprise,
                City = ProprietaryEntity.City
            };
            var actual = repository.GetById(1);
            Assert.Equal(expectedProprietary,actual, new Comparer());
        }
        
        // Checks if GetById returns null if Proprietary is not existing in DbContext
        [Fact]
        public void GetById_ProprietaryIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var list = new List<ProprietaryEntity>()
            {
                new ProprietaryEntity()
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var entity = list.Find(ae => ae.Id == 1);
            var expected = new Proprietary()
            {
                Id = entity.Id,
                CadastreNumber = entity.CadastreNumber,
                ForestryEnterprise = entity.ForestryEnterprise,
                City = entity.City
            };
            var actual = repository.GetById(1);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if Proprietary object is created
        [Fact]
        public void Create_ProprietaryProperties_StoresNewProprietary()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var fakeList = new List<ProprietaryEntity>();
            var expected = new Proprietary()
            {
                CadastreNumber = "123/123:123", 
                ForestryEnterprise = "EsbjergForestry",
                City = "Esbjerg"
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(fakeList);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Create("123/123:123", "EsbjergForestry","Esbjerg");
            Assert.Equal(expected,repository.Create("123/123:123", "EsbjergForestry","Esbjerg"),new Comparer());
        }
        
        // Checks if Proprietary object is updated
        [Fact]
        public void Update_ProprietaryObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var list = new List<ProprietaryEntity>()
            {
                new ProprietaryEntity()
                {
                    Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
                }
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new Proprietary()
            {
                Id = 1, CadastreNumber = "323/323:1323", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"
            };
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Update(expected);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if Delete method deletes object from DB
        [Fact]
        public void Delete_Id_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProprietaryRepository(fakeContext);
            var list = new List<ProprietaryEntity>()
            {
                new ProprietaryEntity(){Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "EsbjergForestry", City = "Esbjerg"}
            };
            fakeContext.Set<ProprietaryEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            var expected = new Proprietary()
            {
                Id = 1
            };
            Assert.Equal(expected,actual,new Comparer());
        }

        private class Comparer: IEqualityComparer<Proprietary>
        {
            public bool Equals(Proprietary x, Proprietary y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.CadastreNumber == y.CadastreNumber && x.ForestryEnterprise == y.ForestryEnterprise && x.City == y.City;
            }

            public int GetHashCode(Proprietary obj)
            {
                return HashCode.Combine(obj.Id, obj.CadastreNumber, obj.ForestryEnterprise, obj.City);
            }
        }
    }
}