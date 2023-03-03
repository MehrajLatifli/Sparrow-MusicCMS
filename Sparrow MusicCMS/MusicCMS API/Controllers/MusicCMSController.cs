using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.ConferencePlanner;
using MusicCMS_Business.Abstract;
using MusicCMS_Entities.Concrete.DatabaseFirst;

namespace MusicCMS_API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MusicCMSController : Controller
    {
        private IAlbumService _albumService;
        private INotificationService _notificationService;
        private IArtistAlbumService _artistAlbumService;
        private IArtistService _artistService;
        private IMusicAlbumService _musicAlbumService;
        private IMusicService _musicService;
        private IPlaylistMusicService _playlistMusicService;
        private IPlaylistService _playlistService;
        private IRadioService _radioService;
        private IUserAccountService _userAccountService;

        private MusicCMSContext _musicCMSContext;

        public MusicCMSController(IAlbumService albumService, INotificationService notificationService, IArtistAlbumService artistAlbumService, IArtistService artistService, IMusicAlbumService musicAlbumService, IMusicService musicService, IPlaylistMusicService playlistMusicService, IPlaylistService playlistService, IRadioService radioService, IUserAccountService userAccountService, MusicCMSContext musicCMSContext)
        {
            _albumService = albumService;
            _notificationService = notificationService;
            _artistAlbumService = artistAlbumService;
            _artistService = artistService;
            _musicAlbumService = musicAlbumService;
            _musicService = musicService;
            _playlistMusicService = playlistMusicService;
            _playlistService = playlistService;
            _radioService = radioService;
            _userAccountService = userAccountService;
            _musicCMSContext = musicCMSContext;
        }



        //Music CRUD
        #region

        [HttpGet("GetMusic")]
        public async Task<IActionResult> GetMusic()
        {
            return Ok(_musicService.GetAll());
        }


        [HttpGet("GetMusicId/{id?}")]
        public IActionResult GetMusicId(int id)
        {
            var item = _musicService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_musicService.GetAll().Where(o => o.IdMusic == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostMusic")]
        public async Task<IActionResult> PostMusic([FromBody] Music item)
        {

            try
            {
                _musicService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateMusic")]
        public async Task<IActionResult> PutMusic([FromBody] Music item)
        {
            try
            {




                _musicService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteMusic/{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            try
            {
                _musicService.Delete(new Music { IdMusic = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //Album CRUD
        #region

        [HttpGet("GetAlbum")]
        public async Task<IActionResult> GetAlbum()
        {
            return Ok(_albumService.GetAll());
        }


        [HttpGet("GetAlbumId/{id?}")]
        public IActionResult GetAlbumId(int id)
        {
            var item = _albumService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_albumService.GetAll().Where(o => o.IdAlbum == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostAlbum")]
        public async Task<IActionResult> PostAlbum([FromBody] Album item)
        {

            try
            {
                _albumService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateAlbum")]
        public async Task<IActionResult> PutAlbum([FromBody] Album item)
        {
            try
            {




                _albumService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteAlbum/{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            try
            {
                _albumService.Delete(new Album { IdAlbum = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //Artist CRUD
        #region
        [HttpGet("GetArtist")]
        public async Task<IActionResult> GetArtist()
        {
            return Ok(_artistService.GetAll());
        }


        [HttpGet("GetArtistId/{id?}")]
        public IActionResult GetArtistId(int id)
        {
            var item = _artistService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_artistService.GetAll().Where(o => o.IdArtist == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostArtist")]
        public async Task<IActionResult> PostArtist([FromBody] Artist item)
        {

            try
            {
                _artistService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateArtist")]
        public async Task<IActionResult> PutArtist([FromBody] Artist item)
        {
            try
            {


                _artistService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteArtist/{id}")]
        public async Task<IActionResult> DeleteArtist( int id)
        {
            try
            {
                _artistService.Delete(new Artist { IdArtist = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //Notification CRUD
        #region
        [HttpGet("GetNotification")]
        public async Task<IActionResult> GetNotification()
        {
            return Ok(_notificationService.GetAll());
        }


        [HttpGet("GetNotificationId/{id?}")]
        public IActionResult GetNotificationId(int id)
        {
            var item = _notificationService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_notificationService.GetAll().Where(o => o.IdNotification == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostNotification")]
        public async Task<IActionResult> PostNotification([FromBody] Notification item)
        {

            try
            {
                _notificationService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateNotification")]
        public async Task<IActionResult> PutNotification([FromBody] Notification item)
        {
            try
            {


                _notificationService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteNotification/{id?}")]
        public async Task<IActionResult> DeleteNotification([FromBody] int id)
        {
            try
            {
                _artistService.Delete(new Artist { IdArtist = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //Radio CRUD
        #region

        [HttpGet("GetRadio")]
        public async Task<IActionResult> GetRadio()
        {
            return Ok(_radioService.GetAll());
        }


        [HttpGet("GetRadioId/{id?}")]
        public IActionResult GetRadioId(int id)
        {
            var item = _radioService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_radioService.GetAll().Where(o => o.IdRadio == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostRadio")]
        public async Task<IActionResult> PostRadio([FromBody] Radio item)
        {

            try
            {
                _radioService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateRadio")]
        public async Task<IActionResult> PutRadio([FromBody] Radio item)
        {
            try
            {


                _radioService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteRadio/{id}")]
        public async Task<IActionResult> DeleteRadio(int id)
        {
            try
            {
                _radioService.Delete(new Radio { IdRadio = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //UserAccount CRUD
        #region

        [HttpGet("GetUserAccount")]
        public async Task<IActionResult> GetUserAccount()
        {
            return Ok(_userAccountService.GetAll());
        }


        [HttpGet("GetUserAccountId/{id?}")]
        public IActionResult GetUserAccountId(int id)
        {
            var item = _userAccountService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_userAccountService.GetAll().Where(o => o.IdUserAccount == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("postuseraccount")]
        public async Task<IActionResult> PostUserAccount([FromBody] UserAccount item)
        {

            try
            {
                _userAccountService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateUserAccount")]
        public async Task<IActionResult> PutUserAccount([FromBody] UserAccount item)
        {
            try
            {


                _userAccountService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteUserAccount/{id?}")]
        public async Task<IActionResult> DeleteUserAccount([FromBody] int id)
        {
            try
            {
                _userAccountService.Delete(new UserAccount { IdUserAccount = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //Playlist CRUD
        #region

        [HttpGet("GetPlaylist")]
        public async Task<IActionResult> GetPlaylist()
        {
            return Ok(_playlistService.GetAll());
        }


        [HttpGet("GetPlaylistId/{id?}")]
        public IActionResult GetPlaylistId(int id)
        {
            var item = _playlistService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_playlistService.GetAll().Where(o => o.IdPlaylist == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("postplaylist")]
        public async Task<IActionResult> PostPlaylist([FromBody] Playlist item)
        {

            try
            {
                _playlistService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdatePlaylist")]
        public async Task<IActionResult> PutPlaylist([FromBody] Playlist item)
        {
            try
            {


                _playlistService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeletePlaylist/{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            try
            {
                _playlistService.Delete(new Playlist { IdPlaylist = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //PlaylistMusic CRUD
        #region

        [HttpGet("GetPlaylistMusic")]
        public async Task<IActionResult> GetPlaylistMusic()
        {
            return Ok(_playlistMusicService.GetAll());
        }


        [HttpGet("GetPlaylistMusicId/{id?}")]
        public IActionResult GetPlaylistMusicId(int id)
        {
            var item = _playlistMusicService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_playlistMusicService.GetAll().Where(o => o.IdPlaylistMusic == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostPlaylistMusic")]
        public async Task<IActionResult> PostPlaylistMusic([FromBody] PlaylistMusic item)
        {

            try
            {
                _playlistMusicService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdatePlaylistMusic")]
        public async Task<IActionResult> PutPlaylistMusic([FromBody] PlaylistMusic item)
        {
            try
            {


                _playlistMusicService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeletePlaylistMusic/{id?}")]
        public async Task<IActionResult> DeletePlaylistMusic([FromBody] int id)
        {
            try
            {
                _playlistMusicService.Delete(new PlaylistMusic { IdPlaylistMusic = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //ArtistAlbum CRUD
        #region

        [HttpGet("GetArtistAlbum")]
        public async Task<IActionResult> GetArtistAlbum()
        {
            return Ok(_artistAlbumService.GetAll());
        }


        [HttpGet("GetArtistAlbumId/{id?}")]
        public IActionResult GetArtistAlbumId(int id)
        {
            var item = _artistAlbumService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_artistAlbumService.GetAll().Where(o => o.IdArtistAlbum == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostArtistAlbum")]
        public async Task<IActionResult> PostArtistAlbum([FromBody] ArtistAlbum item)
        {

            try
            {
                _artistAlbumService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateArtistAlbum")]
        public async Task<IActionResult> PutArtistAlbum([FromBody] ArtistAlbum item)
        {
            try
            {

                _artistAlbumService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteArtistAlbum/{id}")]
        public async Task<IActionResult> DeleteArtistAlbum(int id)
        {
            try
            {
                _artistAlbumService.Delete(new ArtistAlbum { IdArtistAlbum = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

        //MusicAlbum CRUD
        #region

        [HttpGet("GetMusicAlbum")]
        public async Task<IActionResult> GetMusicAlbum()
        {
            return Ok(_musicAlbumService.GetAll());
        }


        [HttpGet("GetMusicAlbumId/{id?}")]
        public IActionResult GetMusicAlbumId(int id)
        {
            var item = _musicAlbumService.GetById(id);

            try
            {
                if (item == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }

                else
                {
                    return Ok(_musicAlbumService.GetAll().Where(o => o.IdMusicAlbum == id));
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();

        }


        [HttpPost("PostMusicAlbum")]
        public async Task<IActionResult> PostMusicAlbum([FromBody] MusicAlbum item)
        {

            try
            {
                _musicAlbumService.Add(item);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }


        [HttpPut("UpdateMusicAlbum")]
        public async Task<IActionResult> PutMusicAlbum([FromBody] MusicAlbum item)
        {
            try
            {

                _musicAlbumService.Update(item);

                //return StatusCode(StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return BadRequest();

        }

        [HttpDelete("DeleteMusicAlbum/{id}")]
        public async Task<IActionResult> DeleteMusicAlbum(int id)
        {
            try
            {
                _musicAlbumService.Delete(new MusicAlbum { IdMusicAlbum = id });

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception)
            {


            }
            return BadRequest();

        }

        #endregion

    }
}
