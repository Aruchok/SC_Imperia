<script type="text/javascript" src="../../Scripts/jquery-1.4.4.js" language="javascript"></script>

@using (Ajax.BeginForm("Sites", new AjaxOptions { UpdateTargetId = "results" }))
{
<fieldset>
    <legend>Create new Location</legend>
        <div id="country">
            @*
              ///<remarks>

              ///</remarks>
            *@
            @{
                Html.Label("Location");
                Html.RenderPartial("_Country"); ;
            }
            @*Html.DropDownList("CountryId", ViewBag.Country as SelectList, "", new { @Id = "ddlCountry", @style = "margin_l_25em", @styles = "styles" })*@
        </div>
        <div id="results">
            @{Html.RenderPartial("_Site");}
        </div>
</fieldset>
}


<script type="text/javascript">
//jQuery for the DropDownList(s) Change Event
    $(this.document).ready(function () {
        $('#ddlCountry').change(function () //wire up on change event of the 'country' dropdownlist
        {
            var selection = $("#ddlCountry").val(); //get the selection made in the dropdownlist
            $('#results').load("/Location/Sites/" + selection); //return value of the url /locations/sites which is the action method to invoke.
        })
    });
</script>