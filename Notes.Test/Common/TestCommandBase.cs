using Notes.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Test.Common
{
    //Abstract class that creating context for tests
    public abstract class TestCommandBase: IDisposable
    {
        public readonly NotesDbContext Context;

        public TestCommandBase()
        {
            Context = NotesContextFactory.Create();
        }
        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}
