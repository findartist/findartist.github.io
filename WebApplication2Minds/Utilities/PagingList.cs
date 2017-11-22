using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2Minds.Utilities
{
    public class PagingList<T> : IEnumerable<T>
    {
        IQueryable<T> _entities;

        public PagingList(IQueryable<T> entities)
        {
            _entities = entities;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int _totalCount = -1;
        public int TotalCount
        {
            get
            {
                if (_totalCount < 0)
                {
                    _totalCount = _entities.Count();
                }
                return _totalCount;
            }
        }

        public int PageCount
        {
            get
            {
                var lastPageSize = TotalCount % PageSize;

                if (lastPageSize == 0)
                {
                    return TotalCount / PageSize;
                }
                else
                {
                    return TotalCount / PageSize + 1;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entities
                .OrderBy((i) => true)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities
                .OrderBy(i=>true)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .GetEnumerator();
        }
    }
}