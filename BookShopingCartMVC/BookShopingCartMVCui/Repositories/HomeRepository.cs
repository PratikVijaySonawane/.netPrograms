using BookShopingCartMVCui.Data;

namespace BookShopingCartMVCui.Repositories
{
    public class HomeRepository
    {
        private readonly ApplicationDbContext _context;
        
        public HomeRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        /* Creating the Methods */
        public void DisplayBooks(string sTerm="",int categoryId = 0)
        {

        }

    }
}
