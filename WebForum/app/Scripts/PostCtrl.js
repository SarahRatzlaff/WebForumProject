app.controller("PostCtrl", function ($scope, $http, $routeParams, $location) {
    $scope.GetPost = function () {
        $http({ method: "GET", url: '/api/v1/Post/' + $routeParams.id })
        .success(function (data) {
            $scope.Post = data;
        })
    }

    $scope.GoToBoard = function () {
        $location.path('/board/' + $routeParams.boardId);
    }
})