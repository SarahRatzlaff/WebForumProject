app.controller("BoardCtrl", function ($scope, $http, $location, $routeParams) {
    $scope.getBoards = function () {
        $http({ method: 'GET', url: '/api/v1/Board/' })
        .success(function (data) {
            $scope.Boards = data;
        })
    }

    $scope.GetBoard = function () {
        $http({ method: 'GET', url: '/api/v1/Board/' + $routeParams.id })
        .success(function (data) {
            $scope.Board = data;
        })
    }

    $scope.GoToBoard = function (id) {
        $location.path('/board/' + id);
    }

    $scope.GoToPost = function (id) {
        $location.path('/board/' + $routeParams.id + '/' + id);
    }
})