using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_Application.UseCases._shared
{
    public interface IUseCaseBase<I,O>
    {
        O execute(I input);
    }
}
