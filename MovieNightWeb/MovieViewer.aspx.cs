using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Movies;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace MovieNightWeb
{
    public partial class MovieViewer : System.Web.UI.Page
    {
        Film movie;

        int movie_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["movieId"] != null) 
            {
                movie_id = int.Parse(Request.QueryString["movieId"]);
            }
            else
            {
                movie_id = 1;
            }

            movie = FilmManager.GetFilm().Find(x => x.Id == movie_id);


            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                thumbNail.Text = $"<img src='{await GetThumbNailAsync()}' alt='{movie.Title}'>";
            }));

            movieTitle.Text += movie.Title;
            movieYear.Text += movie.Year.ToString();

            foreach (Genre genre in movie.Genre)
            {
                movieGenre.Text += genre.Name + " ";
            }

            List<Actor> actors = FilmManager.GetActorInMovies(movie_id, FilmManager.GetFilm());

            foreach (Actor actor in actors)
            {
                movieActors.Text += string.Format($"<div class='col-8 mb-5 text-white'><a href='ActorViewer.aspx?actorId={actor.Id}'>{actor.Firstname} {actor.Lastname}</a></div>");
            }
        }

        protected async Task<string> GetThumbNailAsync() 
        {
            return await FilmManager.GetThumbNailAsync(movie.Title);
        }

        protected void OnClickEdit(object sender, EventArgs e)
        {
            if (editTitle.Text.Length > 0 && editYear.Text.Length > 0) 
            {
                movie.Title = editTitle.Text;
                movie.Year = int.Parse(editYear.Text);
                FilmManager.UpdateFilmData(movie);
                Response.Redirect(HttpContext.Current.Request.RawUrl);
            }else if (editTitle.Text.Length > 0) 
            {
                movie.Title = editTitle.Text;
                FilmManager.UpdateFilmData(movie);
                Response.Redirect(HttpContext.Current.Request.RawUrl);
            }else if (editYear.Text.Length > 0) 
            {
                movie.Year = int.Parse(editYear.Text);
                FilmManager.UpdateFilmData(movie);
                Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
    }
}