'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ChangePasswordCtrl
 * @description
 * # ChangePasswordCtrl
 * Controller where the User change his Password
 */
angular.module('configuratorApp')
    .controller('ChangePasswordCtrl', function ($scope, $rootScope, $sessionStorage,$http,$location,ChangePasswordService)  {
        $rootScope.pagetitle="Passwort ändern";

        $scope.User={};

        $scope.change=function(){
            ChangePasswordService.change({},{
                OldPassword:$scope.User.OldPassword,
                NewPassword:$scope.User.NewPassword,
                ConfirmPassword: $scope.User.ConfirmPassword
            },function (data) {
                swal({title: "Neues Passwort erfolgreich gesetzt", text: "", type: "success"});
            },function (error) {
                $rootScope.errorAlert(error)
            });
        };

    });