using System;

namespace AbdtPractice.Core.Base
{
    public interface IHasCreatedDateString
    {
        DateTime Created { get; }

        string CreatedString { get; }
    }
}