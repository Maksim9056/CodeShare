using CodeShare_Library.Abstractions;
using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CodeShareFiles.Service
{
    public class FilesService : IFilesService
    {
        public readonly CodeShareDB _CodeShareDB;
        //public CodeShareDB _CodeShareDB;
        public FilesService(CodeShareDB codeShareDB)
        {
            _CodeShareDB = codeShareDB;
        }
        public async Task<Image> Create(Image Id)
        {
            try
            {
                await _CodeShareDB.Image.AddAsync(Id);

                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Create   Image {Id.ImageDate} " + " {@Image} registered successfully", Id);

                return Id;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic{Id.ImageId} Rating");
                return new Image();
            }
        }

        public Task<Image> Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> Get(Users Id)
        {
            try
            {
                var image = await _CodeShareDB.Image.FirstOrDefaultAsync(u => u.UserId == Id.UsersId);

                return image;
            }
            catch (Exception ex)
            {
                Log.Error("Exception User {@Imag} registered successfully", ex);
                return new Image() { };


            }
        }

        public Task<Image> Get(int take, HashSet<long> loadedIds)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetLogotype(long Id_Logotype)
        {
            try
            {
                var image = await _CodeShareDB.Image.FirstOrDefaultAsync(u => u.LogotypeId == Id_Logotype);

                return image;
            }
            catch (Exception ex)
            {
                Log.Error("Exception Image {@Imag} registered successfully", ex);
                return new Image() { };


            }
        }

        

        public async Task<Image> Update(Image Id)
        {
            try
            {
                Image Image = await _CodeShareDB.Image.FirstOrDefaultAsync(coment => coment.ImageId == Id.ImageId && coment.UserId == Id.UserId);
                Image.ImageDate = Id.ImageDate;

                if(Image.LogotypeId != 0)
                {
                    Image.LogotypeId = Id.LogotypeId;
                }
               
                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Update User {Image.UserId}  Image {Image.ImageDate} " + " {@Image} registered successfully", Image);

                return Image;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic{Id.ImageId} Rating");
                return new Image();
            }
        }

        public async Task<Image> Update(Image Id, bool Logo)
        {
            try
            {
                Image Image = await _CodeShareDB.Image.FirstOrDefaultAsync(coment => coment.ImageId == Id.ImageId);
                //Image.ImageDate = Id.ImageDate;

              
                    Image.LogotypeId = Id.LogotypeId;
                

                //_CodeShareDB.Comment.Update(comment);

                await _CodeShareDB.SaveChangesAsync();

                Log.Information($"Get Update User {Image.UserId}  Image {Image.ImageDate} " + " {@Image} registered successfully", Image);

                return Image;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + $"GetComment Comment Topic{Id.ImageId} Rating");
                return new Image();
            }

        }
    }
}
