angular.module("umbraco").controller("MessagesDashboardController", function ($http) {
    var self = this;
    self.filter = '';


    $http.get("https://alexander-was-intuitive-penguin.euwest01.umbraco.io/umbraco/api/messages/get").then(function (response) {
        self.messages = response.data;

    });

    self.updateState = function (item) {
        var data = {
            "id": item.id,
            "proceeded": !item.proceeded
        };

        $http({
            url: "https://alexander-was-intuitive-penguin.euwest01.umbraco.io/umbraco/api/messages/update",
            method: 'PUT',
            data: data
        }).then(function (result) {
            if (self.filter == "false") {
                self.messages = self.messages.filter(x => x.id != result.data)
            }
            console.log(result)
        }, function (error) {
            console.log(error)

        });
    }

    self.deleteMessage = function (id) {
        var data = {
            "id": id
        };

        $http({
            url: "https://alexander-was-intuitive-penguin.euwest01.umbraco.io/umbraco/api/messages/delete",
            dataType: 'json',
            method: 'DELETE',
            data: data,
            headers: {
                "Content-Type": "application/json"
            }
        }).then(function (result) {
            self.messages = self.messages.filter(x => x.id != result.data)

        }, function (error) {
            console.log(error)

        });
    }
});