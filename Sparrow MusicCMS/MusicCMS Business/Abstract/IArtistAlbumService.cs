using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicCMS_Business.Abstract
{
    public interface IArtistAlbumService
    {
        List<ArtistAlbum> GetAll();
        List<ArtistAlbum> GetByArtist(int Id);
        List<ArtistAlbum> GetByAlbum(int Id);

        void Add(ArtistAlbum item);
        void Update(ArtistAlbum item);
        void Delete(ArtistAlbum item);
        ArtistAlbum GetById(int Id);
    }
}
