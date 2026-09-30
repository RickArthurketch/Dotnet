using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Application_WPF
{
    public class Photo
    {
        private String _path;
        private Uri _source;
        private PhotoMetadata _phmetadata;

        public DateTime? DateTaken
        {
            get
            {
                Object val = _phmetadata.DateTaken;
                if (val != null)
                {
                    return Convert.ToDateTime(_phmetadata.DateTaken.ToString());
                }
                else
                {
                    return null;
                }
            }
        }


        public string Titre
        {
            get
            {
                if (_phmetadata != null)
                {
                    return _phmetadata.Title;
                }
                return null;
            }
        }
        public string Camera
        {
            get
            {
                if (_phmetadata != null)
                {
                    string fabricant = _phmetadata.CameraManufacturer;
                    string modele = _phmetadata.CameraModel;

                    return (fabricant + " " + modele).Trim();
                }
                return null;
            }
        }

        public string Application
        {
            get
            {
                if (_phmetadata != null)
                {
                    object val = _phmetadata.Application;
                    return (val != null ? (string)val : String.Empty);
                }
                return String.Empty;
            }
        }

        public string IsoSpeed
        {
            get
            {
                if (_phmetadata != null)
                {
                    return _phmetadata.IsoSpeed;
                }
                return String.Empty;
            }
        }

        public decimal? Ouverture
        {
            get
            {
                if (_phmetadata != null)
                {
                    return _phmetadata.Ouverture;
                }
                return null;
            }
        }

        public decimal? DistanceFocale
        {
            get
            {
                if (_phmetadata != null)
                {
                    return _phmetadata.DistanceFocale;
                }
                return null;
            }
        }
        public Photo(String path)
        {
            _path = path;
            if (path != "")
            {
                _source = new Uri(path);
                _phmetadata = new PhotoMetadata(_source);
            }
            else
            {
                _source = null;
            }
            
        }

        public override string ToString()
        {
            return _path;
        }

        public string Source
        {
            get { return _path; }
        }

        public PhotoMetadata Metadata { get { return _phmetadata; } }


        public class PhotoMetadata
        {
            private BitmapMetadata _metadata;

            public PhotoMetadata(Uri imageUri)
            {
                BitmapFrame frame = BitmapFrame.Create(imageUri, BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                _metadata = (BitmapMetadata)frame.Metadata;
            }

            public string DateTaken
            {
                get
                {
                    if (_metadata != null)
                        return _metadata.DateTaken;
                    return null;
                }
            }

            public string Application
            {
                get
                {
                    if (_metadata != null)
                    {
                        object val = _metadata.ApplicationName;
                        return (val != null ? (string)val : String.Empty);
                    }
                    return String.Empty;
                }
            }

            public string Title { get { return _metadata?.Title;  } }
            public string CameraManufacturer { get { return _metadata?.CameraManufacturer; } }
            public string CameraModel { get { return _metadata?.CameraModel; } }

            private decimal ParseUnsignedRational(ulong exifValue)
            {
                return (decimal)(exifValue & 0xFFFFFFFFL) / (decimal)((exifValue & 0xFFFFFFFF00000000L) >> 32);
            }
            private decimal ParseSignedRational(long exifValue)
            {
                return (decimal)(exifValue & 0xFFFFFFFFL) / (decimal)((exifValue & 0x7FFFFFFF00000000L) >> 32);
            }
            private object QueryMetadata(string query)
            {
                if (_metadata.ContainsQuery(query))
                    return _metadata.GetQuery(query);
                else
                    return null;
            }

            public string IsoSpeed
            {
                get
                {
                    object val = QueryMetadata("/app1/ifd/exif/subifd:{uint=34855}");
                    return (val != null ? val.ToString() : String.Empty);
                }
            }

            public decimal? Ouverture
            {
                get
                {
                    object val = QueryMetadata("/app1/ifd/exif/subifd:{uint=33437}");
                    return (val != null ? ParseUnsignedRational((ulong)val) : (decimal?)null);
                }
            }

            public decimal? DistanceFocale
            {
                get
                {
                    object val = QueryMetadata("/app1/ifd/exif/subifd:{uint=37386}");
                    // La distance focale est également stockée sous forme de fraction non signée
                    return (val != null ? ParseUnsignedRational((ulong)val) : (decimal?)null);
                }
            }
        }
    }

}
