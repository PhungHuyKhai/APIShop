﻿
using DaTaAcessLayer.Interfaces;
using DataModel;
using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DanhMucBusiness : IDanhMucBusiness
    {
        private IDanhMucReporitory _res;
        public DanhMucBusiness(IDanhMucReporitory res)
        {
            _res = res;
        }
        public DanhMucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(DanhMucModel model)
        {
            return _res.Delete(model);
        }

        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }


    }
}
