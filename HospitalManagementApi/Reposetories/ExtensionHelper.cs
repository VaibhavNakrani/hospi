using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HospitalManagementApi.Reposetories
{
    public static class ExtensionHelper
    {
        public static async Task SaveAsync(this IFormFile file, string pathWithName, CancellationToken cancellationToken)
        {
            var stream = new FileStream(pathWithName, FileMode.Create);
            await using var _ = stream.ConfigureAwait(false);
            await file.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
