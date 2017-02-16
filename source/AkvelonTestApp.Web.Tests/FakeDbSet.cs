using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace AkvelonTestApp.Web.Tests
{
	public class FakeDbSet<T> : IDbSet<T> where T : class
	{
		readonly ObservableCollection<T> _data;
		readonly IQueryable _query;

		public FakeDbSet()
		{
			_data = new ObservableCollection<T>();
			_query = _data.AsQueryable();
		}

		public virtual T Find(params object[] keyValues)
		{
			throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
		}

		public T Add(T item)
		{
			_data.Add(item);
			return item;
		}

		public T Remove(T item)
		{
			_data.Remove(item);
			return item;
		}

		public T Attach(T item)
		{
			_data.Add(item);
			return item;
		}

		public T Detach(T item)
		{
			_data.Remove(item);
			return item;
		}

		public T Create() => Activator.CreateInstance<T>();

		public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
			=> Activator.CreateInstance<TDerivedEntity>();

		public ObservableCollection<T> Local => _data;

		Type IQueryable.ElementType => _query.ElementType;

		System.Linq.Expressions.Expression IQueryable.Expression => _query.Expression;

		IQueryProvider IQueryable.Provider => _query.Provider;

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			=> _data.GetEnumerator();

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => _data.GetEnumerator();
	}
}