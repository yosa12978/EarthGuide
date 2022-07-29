using EarthGuide.Core.Domain;
using EarthGuide.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data.InMemory
{
    public class SightplaceRepository : ISightplaceRepository
    {
        List<Sightplace> sightplaces = new List<Sightplace>();
        public async Task Create(Sightplace entity)
        {
            sightplaces.Add(entity);
        }

        public async Task Delete(string id)
        {
            sightplaces.Remove(sightplaces.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Sightplace>> GetAll()
        {
            return sightplaces;
        }

        public async Task<Sightplace> GetById(string id)
        {
            return sightplaces.FirstOrDefault(s => s.Id == id);
        }

        public async Task Update(string id, Sightplace entity)
        {
            sightplaces[sightplaces.IndexOf(sightplaces.FirstOrDefault(x => x.Id == id))] = entity;
        }
    }
}
