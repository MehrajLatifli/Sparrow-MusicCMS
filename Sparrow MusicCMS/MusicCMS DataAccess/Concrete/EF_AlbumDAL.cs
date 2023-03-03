using MusicCMS_Core.Data_Access.EntityFrameworkCore;
using MusicCMS_DataAccess.Abstract;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCMS_DataAccess.Concrete
{
    public class EF_AlbumDAL : EF_EntityRepositoryBase<Album, MusicCMSContext>, IAlbumDAL
    {

    }
}
