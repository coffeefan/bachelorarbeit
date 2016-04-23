'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:ConfirmRegistrationCtrl
 * @description
 * # ConfirmRegistrationCtrl
 * Controller where the User confirm his Registration
 */
angular.module('configuratorApp')
    .controller('ConfirmRegistrationCtrl', function ($scope, $rootScope, $routeParams,ConfirmRegistrationService,
                                             $sessionStorage,$location) {
        $rootScope.pageTitle="Überprüfe Registration";
        $scope.User={};
        $scope.User.UserId=$routeParams.UserId;
        $scope.User.Code=$routeParams.Code;
        $scope.confirm=function(){
            ConfirmRegistrationService.confirm({
                UserId:$scope.User.UserId,
                Code:$scope.User.Code
            },{
            },function (data) {
                swal({title: "Ihre E-Mail wurde erfolgreich bestätigt", text: "", type: "success"},function(){
                    $scope.$apply(function() { $location.path("/login"); });
                });
            },function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.confirm();

    });
