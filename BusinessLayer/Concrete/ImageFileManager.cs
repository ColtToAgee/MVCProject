﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal imagefileDal;

        public ImageFileManager(IImageFileDal imagefileDal)
        {
            this.imagefileDal = imagefileDal;
        }

        public List<ImageFile> GetList()
        {
            throw new NotImplementedException();
        }
    }
}