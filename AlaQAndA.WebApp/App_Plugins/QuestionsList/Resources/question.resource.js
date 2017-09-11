angular.module("umbraco.resources")
        .factory("questionResource", function ($http) {
            return {
                getall: function () {
                    return $http.get("backoffice/Questions/QuestionsApi/GetAll");
                },

                deleteById: function(selectedIds) {
                    return $http.post("backoffice/Questions/QuestionsApi/Delete?id=" + selectedIds[0]);
                }

                //getPaged: function (itemsPerPage, pageNumber, sortColumn, sortOrder, searchTerm) {
                //    if (sortColumn == undefined)
                //        sortColumn = "";
                //    if (sortOrder == undefined)
                //        sortOrder = "";
                //    return $http.get(Umbraco.Sys.ServerVariables.questionSection.questionBaseUrl + "GetPaged?itemsPerPage=" + itemsPerPage + "&pageNumber=" + pageNumber + "&sortColumn=" + sortColumn + "&sortOrder=" + sortOrder + "&searchTerm=" + searchTerm);
                //}
            };
        });