using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IArtistService
    {
        List<Artist> GetAll();

        void Add(Artist item);
        void Update(Artist item);
        void Delete(Artist item);
        Artist GetById(int Id);
    }
}
