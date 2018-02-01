using FluentValidation;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;
using System.Text.RegularExpressions;
using NzbDrone.Core.MetadataSource.RadarrAPI;

namespace NzbDrone.Core.NetImport.Radarr
{

    public class RadarrSettingsValidator : AbstractValidator<RadarrSettings>
    {
        private static readonly Regex AdditionalParametersRegex = new Regex(@"(&.+?\=.+?)+", RegexOptions.Compiled);
        private static readonly Regex YearRangeRegex = new Regex(@"(19|20)\d{2}<>(19|20)\d{2}", RegexOptions.Compiled);
        private static readonly Regex PopularityRangeRegex = new Regex(@"\d+(\.\d+)?<>\d+(\.\d+)?", RegexOptions.Compiled);

        
        public RadarrSettingsValidator()
        {
            RuleFor(c => c.APIURL).ValidRootUrl();
            RuleFor(c => c.AdditionalParameters).Matches(AdditionalParametersRegex)
                .When(c => !c.AdditionalParameters.IsNullOrWhiteSpace());
            RuleFor(c => c.YearRange).Matches(YearRangeRegex)
                .When(c => !c.YearRange.IsNullOrWhiteSpace());
            RuleFor(c => c.PopularityRange).Matches(PopularityRangeRegex)
                .When(c => !c.PopularityRange.IsNullOrWhiteSpace());
        }
    }

    public class RadarrSettings : IProviderConfig
    {
        private static readonly RadarrSettingsValidator Validator = new RadarrSettingsValidator();

        public RadarrSettings()
        {
            APIURL = "https://api.radarr.video/v2";
            Path = "";
            HideAdult = true;
        }

        [FieldDefinition(0, Label = "Radarr API URL", HelpText = "Link to to Radarr API URL. Use https://staging.api.radarr.video if you are on nightly.")]
        public string APIURL { get; set; }

        [FieldDefinition(1, Label = "Path to list", HelpText = "Path to the list proxied by the Radarr API. Check the wiki for available lists.")]
        public string Path { get; set; }
        
        //[FieldDefinition(2, Type = FieldType.Checkbox, Label = "Hide added and ignored", HelpText = "Hide movies that are already added to Radarr or that are on your ignore list.")]
        //public bool HideAddedIgnored { get; set; }
        
        [FieldDefinition(2, Label = "Year Range", HelpText = "Range of years to be included. Needs to be in the form of start_year<>end_year.")]
        public string YearRange { get; set; }
        
        [FieldDefinition(3, Label = "Popularity Range", HelpText = "Range of popularity to be included. Needs to be in the form of lower_bound<>upper_bound.")]
        public string PopularityRange { get; set; }
        
        [FieldDefinition(4, Type = FieldType.Checkbox, Label = "Hide adult movies")]
        public bool HideAdult { get; set; }
        
        [FieldDefinition(5, Label = "Additional parameters", HelpText = "Additional parameters. See the wiki for what you can add here.", HelpLink = "https://github.com/Radarr/Radarr/wiki/Supported-NetImports#additional-parameters-to-filter-by")]
        public string AdditionalParameters { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }

}