using MusicCMS_Core.Data_Access;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_DataAccess.Abstract
{
    public interface IAlbumDAL : IEntityRepository<Album>
    {
    }
}
