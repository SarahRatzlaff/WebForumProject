app.controller("GlobalCtrl", function ($scope, $http, $location) {
    $scope.Login = function () {
        $http({ method: "POST", url: "/api/v1/Login", data: $scope.User })
        .success(function (data) {
            localStorage.setItem("CurrentUser", JSON.stringify(data));
            $location.path('/');
        })
        .error(function () { alert("Error"); })
    };

    $scope.Logout = function () {
        localStorage.removeItem("CurrentUser");
        $location.path('/');
    }

    $scope.ReturnToIndex = function () {
        $location.path('/');
    };

    $scope.GoToLogin = function () {
        $location.path('/login');
    };

    $scope.GoToRegister = function () {
        $location.path('/register');
    };

    $scope.checkLogin = function () {
        if (localStorage.getItem("CurrentUser") != null) {
            return true;
        } else {
            return false;
        }
    };

    $scope.Register = function () {
        $http({ method: "POST", url: "/api/v1/Users/", data: $scope.NewUser })
        .success(function () { $location.path('/login') })
        .error(function () { alert("Error"); })
    };
});