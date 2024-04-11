namespace EasyTestClient.ClientState
{
    public abstract class BaseState
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void Do();
        
    }
}
