'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('RegistrationCtrl', function ($scope, $rootScope,$location,RegistrationService) {
        $rootScope.pageTitle = "Registration";

        $scope.requestRegistration = function () {
            RegistrationService.add({}, $scope.registration, function (data) {

                swal({title: "Dein Account wurde erfolgreich erstellt", text: "In wenigen Augenblicken erhältst Du eine E-Mail zur Bestätigung", type: "success"}, function () {
                    $scope.$apply(function() { $location.path("/route"); });
                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };


    });