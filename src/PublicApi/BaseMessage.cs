using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicApi;
/// <summary>
/// Base class used by API requests
/// </summary>
public abstract class BaseMessage
{
    /// <summary>
    /// unique identifier used by logging
    /// </summary>
    protected Guid _correlationId = Guid.NewGuid();
    public Guid CorrelationId()
    {
        return _correlationId;
    }

    
}
