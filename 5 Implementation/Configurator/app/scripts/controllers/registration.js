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

                swal({title: "Ihr Account wurde erfolgreich erstellt", text: "In wenigen Augenblicken erhalten Sie eine E-Mail zur Bestätigung", type: "success"}, function () {
                    $location.path("/");
                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };


    });