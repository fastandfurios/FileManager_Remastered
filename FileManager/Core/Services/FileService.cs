﻿using FileManager.Core.Services.Interfaces;

namespace FileManager.Core.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        /// <summary> Копирует существующий файл в новый файл </summary>
        /// <param name="sourceName">копируемый файл</param>
        /// <param name="destName">имя целевого файла</param>
        public void Copy(string sourceName, string destName)
        {
            try
            {
                if(File.Exists(destName))
                    File.Delete(destName);

                File.Copy(sourceName, destName);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }   
            catch (NotSupportedException ex)
            {   
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary> Создает файлы </summary>
        /// <param name="name">имя файла</param>
        /// <returns>результат выполнения</returns>
        public bool Create(string name)
        {
            try
            {
                if(File.Exists(name))
                    File.Delete(name);

                using var fileStream = File.Create(name);
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary> Удаляет файл </summary>
        /// <param name="name">имя файла</param>
        /// <returns>результат выполнения</returns>
        public bool Delete(string name)
        {
            try
            {
                if (File.Exists(name))
                    File.Delete(name);

                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary> Получает размер файла в байтах </summary>
        /// <param name="name">имя файла</param>
        /// <returns>размер файла в байтах</returns>
        public void GetSize(string name, out long size)
        {
            try
            {
                var fileInfo = new FileInfo(name);
                size = fileInfo.Length;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                size = 0;
            }
        }

        /// <summary> Перемещает файл </summary>
        /// <param name="sourcePath">начальный путь</param>
        /// <param name="destPath">конечный путь</param>
        /// <returns>результат операции</returns>
        public void Move(string sourcePath, string destPath)
        {
            try
            {
                if(!File.Exists(destPath))
                    File.Delete(destPath);

                File.Move(sourcePath, destPath);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
