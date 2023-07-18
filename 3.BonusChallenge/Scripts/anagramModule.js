var AnagramModule = function () {
    var getAnagrams = function (words) {
        debugger;
        return $.ajax({
            url: "/Home/GetSimpleListAnagrams",
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify({ words: words }),
            dataType: "json",
            success: function (data) {
                return data;
            },
            error: function (error) {
                console.error(error);
                return { success: false, message: "An error occurred while fetching anagrams." };
            }
        });
    };

    var displayAnagrams = function (resultModel) {
        debugger;
        var anagramResultDiv = $("#anagramResultDiv");
        if (resultModel.success) {
            var table = $("<table></table>");
            resultModel.data.AnagramLists.forEach(function (anagrams) {
                var row = $("<tr></tr>");
                anagrams.forEach(function (word) {
                    var cell = $("<td></td>").text(word);
                    row.append(cell);
                });
                table.append(row);
            });
            anagramResultDiv.empty(); // Clear the previous results
            anagramResultDiv.append(table);
        } else {
            anagramResultDiv.html("Error: " + resultModel.message);
        }
    };

    return {
        getAnagrams: getAnagrams,
        displayAnagrams: displayAnagrams,
    };
};

