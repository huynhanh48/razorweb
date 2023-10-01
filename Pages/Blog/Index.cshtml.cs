using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MigrationsExample.Models;

namespace MigrationsExample.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly MigrationsExample.Models.MyBlogContext _context;

        public IndexModel(MigrationsExample.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;
        public const int Item_Pages = 5;

        [BindProperty(SupportsGet =true , Name = "p") ]
        public int currentPage {set;get;}

        public int coutPage{set;get;}

        public async Task OnGetAsync(string SearchString)
        {
            int totalPages =await _context.article.CountAsync();
            coutPage = (int)Math.Ceiling((double)totalPages/Item_Pages);
            if (currentPage<=1)
            {
                coutPage=1;
            }
            if(currentPage>coutPage)
            {
                currentPage=coutPage;
            }
            if (_context.article != null)
            {
               // Article = await _context.article.ToListAsync();
                var qr = (from a in _context.article
                orderby a.PublishDate descending
                select a).Skip((currentPage-1)*10).Take(Item_Pages);
                if(!string.IsNullOrEmpty(SearchString))
                {
                    
                    Article = qr.Where(a=> a.Title.Contains(SearchString)).ToList();
                   
                }
                else
                {
                    
                    Article= await qr.ToListAsync(); 
                }

                  
              
            }
        
        }
    }
}
