namespace Domain.Exceptions
{
    public class InvalidImageException : Exception
    {
        public InvalidImageException(string uri, string altText) : base($"Image with Uri = \"{uri}\" and alt text = {altText} has not valid format.")
        {
        }
    }
}
