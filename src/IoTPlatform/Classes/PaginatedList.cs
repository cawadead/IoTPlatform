﻿using Amazon.SecurityToken.Model;

namespace IoTPlatform.Classes
{
    public class PaginatedList<T>
    {
        private readonly int _pageSize;
        private readonly List<List<T>> _list;
        private readonly int _pagesCount;

        public PaginatedList(List<T> list, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _pageSize = pageSize;
            _list = new List<List<T>>();
            var data = (float)list.Count / pageSize;
            _pagesCount = (int)Math.Ceiling(data);
            for (int i = 0; i < _pagesCount; i++)
            {
                _list.Add(GetListPage(list, pageSize, i));
            }
        }

        public List<List<T>> GetList()
        {
            return _list;
        }

        /// <summary>
        /// Получить часть передаваемого объекта List с элементами находящимися на заданной странице
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public List<T> GetListPage(int pageNumber)
        {
            return _list.ElementAt(pageNumber);
        }

        /// <summary>
        /// Получить часть передаваемого объекта List с элементами находящимися на заданной странице
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static List<T> GetListPage(List<T> list, int pageSize, int pageNumber)
        {
            if (list.Count < pageNumber * pageSize)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (pageNumber < 0 || pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return list.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }
    }
}
