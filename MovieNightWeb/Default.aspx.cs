using System;
using System.Collections.Generic;
using Movies;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace MovieNightWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["search"] == null) 
            {
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    GetFilmsText.Text += await GetFilmsAsync();
                }));
            }
            else
            {
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    GetFilmsText.Text += await GetSearchedFilmsAsync();
                }));
            }
            
            
        }

        protected async Task<string> GetSearchedFilmsAsync()
        {
            //string FilmTitleWithPic
            string kage = "";
            List<Film> films = FilmManager.GetSearchFilm(Request.QueryString["search"]);
            for (int i = 0; i < films.Count; i++)
            {
                if (i + 1 < films.Count)
                {
                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<img class='col-4 col-sm-4 col-md-4' src='{await FilmManager.GetThumbNailAsync(films[i].Title)}' alt='{films[i + 1].Title}'>");

                    kage += string.Format($"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<img class='col-5 col-sm-5 col-md-5' src='{await FilmManager.GetThumbNailAsync(films[i + 1].Title)}' alt='{films[i + 1].Title}'>");

                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<div class='col-4 col-sm-4 col-md-4 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i].Id}' role='button'>{films[i].Title}</a>" +
                        $"</div>");

                    kage += string.Format($"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<div class='col-5 col-sm-5 col-md-5 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i + 1].Id}' role='button'>{films[i + 1].Title}</a>" +
                        $"</div>");

                    i++;
                }
                else
                {
                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<img class='col-4 col-sm-4 col-md-4' src='{await FilmManager.GetThumbNailAsync(films[i].Title)}' alt='{films[i].Title}'>");

                    kage += string.Format($"<div class='col-6 col-sm-6 col-md-6'>" +
                        $"</div>" +
                        $"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<div class='col-2 col-sm-2 col-md-2 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i].Id}' role='button'>{films[i].Title}</a>" +
                        $"</div>");
                }


            }
            return kage;

        }
        protected async Task<string> GetFilmsAsync() 
        {
            //string FilmTitleWithPic
            string kage = "";
            List<Film> films = FilmManager.GetFilm();
            for (int i = 0; i < films.Count; i++)
            {
                if (i + 1 < films.Count)
                {
                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<img class='col-4 col-sm-4 col-md-4' src='{await FilmManager.GetThumbNailAsync(films[i].Title)}' alt='{films[i + 1].Title}'>");

                    kage += string.Format($"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<img class='col-5 col-sm-5 col-md-5' src='{await FilmManager.GetThumbNailAsync(films[i + 1].Title)}' alt='{films[i + 1].Title}'>");

                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<div class='col-4 col-sm-4 col-md-4 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i].Id}' role='button'>{films[i].Title}</a>" +
                        $"</div>");

                    kage += string.Format($"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<div class='col-5 col-sm-5 col-md-5 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i + 1].Id}' role='button'>{films[i + 1].Title}</a>" +
                        $"</div>");

                    i++;
                }
                else
                {
                    kage += string.Format($"<div class='col-1 col-sm-1 col-md-1'>" +
                        $"</div>" +
                        $"<img class='col-4 col-sm-4 col-md-4' src='{await FilmManager.GetThumbNailAsync(films[i].Title)}' alt='{films[i].Title}'>");

                    kage += string.Format($"<div class='col-6 col-sm-6 col-md-6'>" +
                        $"</div>" +
                        $"<div class='col-2 col-sm-2 col-md-2'>" +
                        $"</div>" +
                        $"<div class='col-2 col-sm-2 col-md-2 text-center'>" +
                        $"<a class='text-white btn btn-success' href='MovieViewer.aspx?movieId={films[i].Id}' role='button'>{films[i].Title}</a>" +
                        $"</div>");
                }


            }
            return kage;

        }
    }
}