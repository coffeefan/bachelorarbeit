'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('ProjectDetailCtrl', function ($scope, $rootScope,$location,ProjectService,$routeParams) {
        $rootScope.pageTitle = "Projekt Detail";
        $scope.project={};
        $scope.project.ProjectId=$routeParams.projectId;



        $scope.saveProject = function () {

            if($scope.project.ProjectId==-1){
                $scope.addProject();
            }else{
                $scope.updateProject();
            }
        };

        $scope.loadProject= function($projectid){
            ProjectService.find({id:$projectid}, $scope.project, function (data) {

                $scope.project=data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.addProject = function(){
            delete $scope.project.ProjectId;
            ProjectService.add({}, $scope.project, function (data) {

                swal({title: "Speicherung erfolgreich", text: "Das Projekt wurde erfolgreich erstellt", type: "success"}, function () {
                    $location.path("/");
                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.updateProject = function(){
            ProjectService.update({id:$scope.project.ProjectId}, $scope.project, function (data) {

                swal({title: "Speicherung erfolgreich", text: "Das Projekt wurde erfolgreich erstellt", type: "success"}, function () {
                    $location.path("/");
                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };



        if($scope.project.ProjectId!=-1){
            $scope.loadProject($scope.project.ProjectId);
        }

    });