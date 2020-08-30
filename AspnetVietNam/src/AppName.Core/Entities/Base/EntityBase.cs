namespace AppName.Core.Entities.Base
{
    public class EntityBase<TKey> : TEntityBase<TKey>
    {
        public virtual TKey Id { get; protected set; }

        int? _requestedHashCode;

        public bool IsTransient()
        {
            return Id.Equals(default(TKey));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TKey>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase<TKey>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; 
                // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            return !(left == right);
        }
    }
}
