using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Image : ValueObject
    {
        private Image(Uri uri, string altText)
        {
            Uri = uri;
            AltText = altText;
        }

        public Uri Uri { get; private set; }

        public string AltText { get; private set; }

        public static Image From(string uri, string altText)
        {
            var isUriValid = Uri.TryCreate(uri, UriKind.Absolute, out var outUri) &&
                             (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
            var isAltTextValid = !string.IsNullOrEmpty(altText);
            
            if (!isUriValid || !isAltTextValid)
            {
                throw new InvalidImageException(uri, altText);
            }

            var image = new Image(outUri!, altText);
            return image;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Uri;
            yield return AltText;
        }
    }
}
