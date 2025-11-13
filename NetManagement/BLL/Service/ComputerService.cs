using DAL.Entities;
using DAL.Reposibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public  class ComputerService
    {
        private ComputerRepo _computerrepo = new();

        public void DeleteComputer(Computer obj)
        {
            _computerrepo.Delete(obj);
        }
        public List<Computer> GetAllComputer()
        {
            return _computerrepo.GetAllComputer();
        }

        public List<string> GetDistinctStatuses()
        {
            return _computerrepo.GetDistinctStatuses();
        }

        public List<Computer> Search(string keyword, string status)
        {
            return _computerrepo.Search(keyword, status);
        }
    }
}
