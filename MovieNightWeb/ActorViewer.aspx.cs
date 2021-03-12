using System;
using Movies;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieNightWeb
{
    public partial class ActorViewer : System.Web.UI.Page
    {
        Actor actor;

        int actor_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["actorId"] != null) 
            {
                actor_id = int.Parse(Request.QueryString["actorId"]);
                
            }
            else
            {
                actor_id = 1;
            }
            GetActorInfo();
        }

        protected void GetActorInfo() 
        {
            List<Actor> actors = FilmManager.GetActor();

            actor = FilmManager.GetActor().Find(x => x.Id == actor_id);

            ActorInfo.Text = actor.Firstname + " " + actor.Lastname;

            List<Film> films = FilmManager.GetFilmsFromActor(actor_id, FilmManager.GetActor());

            foreach (Film film in films)
            {
                ActorMovies.Text += $"<div class='col-10'><a class='text-white' href='MovieViewer.aspx?movieId={film.Id}'>{film.Title}</a></div>";
            }

        }
    }
}