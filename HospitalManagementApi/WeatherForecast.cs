/*string.Join(null, Guid.NewGuid().ToString().Split('-')) + Path.GetExtension(file.FileName),

 public static async Task SaveAsync(this IFormFile file, string pathWithName, CancellationToken cancellationToken)
{
    var stream = new FileStream(pathWithName, FileMode.Create);
    await using var _ = stream.ConfigureAwait(false);
    await file.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
    await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
}


await file.SaveAsync($"{_savePath}\\Dealer\\{dbModel.Image}", cancellationToken).ConfigureAwait(false);

".Png",
        ".Jpg",
        ".Jpeg",
        ".Bmp"

 
  if (!ModelState.IsValid)
            {
                var message = ModelState.Values
                    .SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToArray();

                return BadRequest(message);
            }
 
 
 
 var success = string.Compare("","", StringComparison.InvariantCultureIgnoreCase);
 */