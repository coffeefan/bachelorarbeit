'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.controller:RegistrationCtrl
 * @description
 * # RegistrationCtrl
 * Controller where the User can registrate himself
 */
angular.module('configuratorApp')
    .controller('ProjectDetailCtrl', function ($scope, $rootScope,$location,ProjectService,$routeParams,$uibModal,
                                               AvailableSecurityService,SecurityStepProjectListService,
                                               SecurityStepCompareInfoService,SecurityStepSurvey) {
        $rootScope.pageTitle = "Projekt Detail";
        $scope.project={};
        $scope.infobox={
        };
        $scope.securityStepCompareInfo={}
        $scope.securityStepCompareInfo.data=[];
        $scope.securityStepCompareInfo.labels=[];
        $scope.project.ProjectId=$routeParams.projectId;
        $scope.availableSecuritySteps=[];
        $scope.projectSecuritySteps=[];
        $scope.securitySteps=[];
        $scope.securitystepselected="";
        $scope.surveyAge={};
        $scope.surveyTotal={};

        //SecurityStep Configuration
        $scope.models = {
            selected: null,
            lists: {"A": [], "B": []}
        };

        // Generate initial model
        for (var i = 1; i <= 3; ++i) {
            $scope.models.lists.A.push({label: "Item A" + i});
            $scope.models.lists.B.push({label: "Item B" + i});
        }

        // Model to JSON for demo purpose
        $scope.$watch('models', function(model) {
            $scope.modelAsJson = angular.toJson(model, true);
        }, true);



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

        $scope.loadSecurityStepProjectList= function($projectid){
            SecurityStepProjectListService.findAll({projectid:$projectid}, $scope.project, function (data) {

                $scope.organizeSecurityStepProject(data);

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.saveSecurityStepProjectList = function(){

            var projectSecuritySteps=[];
            var zaehler=0;
            angular.forEach($scope.projectSecuritySteps, function(projectSecurityStep) {
                projectSecuritySteps.push(
                    {
                        ProjectId:$scope.project.ProjectId,
                        SecurityStep:projectSecurityStep,
                        Position:zaehler
                    }
                );
                zaehler++;
            });

            SecurityStepProjectListService.update({projectid: $scope.project.ProjectId}, projectSecuritySteps, function (data) {

                swal({title: "Speicherung erfolgreich", text: "Das Projekt wurde erfolgreich erstellt", type: "success"}, function () {

                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };




        $scope.addProject = function(){
            delete $scope.project.ProjectId;
            ProjectService.add({}, $scope.project, function (data) {

                swal({title: "Speicherung erfolgreich", text: "Das Projekt wurde erfolgreich erstellt", type: "success"}, function () {
                    window.location="/#/projects/detail/"+data.ProjectId;
                });

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.updateProject = function(){
            ProjectService.update({id:$scope.project.ProjectId}, $scope.project, function (data) {

                swal({title: "Speicherung erfolgreich", text: "Das Projekt wurde erfolgreich erstellt", type: "success"}, function () {

                });


            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadSecuritySteps= function(){
            AvailableSecurityService.findAll({}, $scope.project, function (data) {
                $scope.securitySteps=data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadSecurityStepInfo= function(securitystepname){
            SecurityStepCompareInfoService.find({securitystepname:securitystepname+"Info"}, {}, function (data) {
                $scope.securityStepCompareInfo.labels=data.labels;
                $scope.securityStepCompareInfo.data=data.data;
            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadSurveyAge= function(securitystepname){
            var securitystepshortname=securitystepname.replace("SecurityStep","").toLowerCase();
            SecurityStepSurvey.find({typ:"AgeStep",securitystepshortname:securitystepshortname}, {}, function (data) {
                $scope.surveyAge=data;

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };

        $scope.loadSurveyTotal= function(securitystepname){
            var securitystepshortname=securitystepname.replace("SecurityStep","").toLowerCase();
            SecurityStepSurvey.find({typ:"TotalStep",securitystepshortname:securitystepshortname}, {}, function (data) {
                $scope.surveyTotal=data;

            }, function (error) {
                $rootScope.errorAlert(error)
            });
        };



        $scope.organizeSecurityStepProject= function(projectSecuritySteps){
            $scope.availableSecuritySteps=$scope.securitySteps;
            for(var i=0;i<$scope.availableSecuritySteps.length;i++) {
                $scope.availableSecuritySteps[i] = $scope.availableSecuritySteps[i].replace("Info", "");
            }
            $scope.projectSecuritySteps=[];
            for(var z=0;z<projectSecuritySteps.length;z++){

                for(var i=0;i<$scope.availableSecuritySteps.length;i++){
                    if(projectSecuritySteps[z].SecurityStep==$scope.availableSecuritySteps[i]){
                        $scope.projectSecuritySteps.push(projectSecuritySteps[z].SecurityStep);
                        $scope.availableSecuritySteps.splice(i, 1);
                    }
                }
            }


        };

        $scope.movedAvailableSecurityStepst= function(index,securitystep){
            $scope.availableSecuritySteps.splice(index, 1);
            $scope.saveSecurityStepProjectList();
            $scope.open(500,securitystep);
        };

        $scope.movedProjectSecurityStep= function(index,securitystep){
            $scope.projectSecuritySteps.splice(index, 1);
            $scope.saveSecurityStepProjectList();
        };

        $scope.changeselectedSecurityStep=function(item){
            $scope.infobox.securitystepselected=item;
            $scope.loadSecurityStepInfo(item);
            $scope.loadSurveyAge(item);
            $scope.loadSurveyTotal(item);
        };



        if($scope.project.ProjectId!=-1){
            $scope.loadSecuritySteps();
            $scope.loadSecurityStepProjectList($scope.project.ProjectId);
            $scope.loadProject($scope.project.ProjectId);
        }

        $scope.success = function () {
            console.log('Copied!');
            $rootScope.showAlert("alertCopied");
        };

        $scope.fail = function (err) {
            console.error('Error!', err);
            return false;
        };







        $scope.animationsEnabled = true;

        $scope.open = function (size,securitystep) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'configSecurityStep.html',
                controller: 'ModalInstanceCtrl',
                size: size,
                resolve: {
                    securitystepname: function () {
                        return securitystep;
                    },
                    projectId: function(){
                        return $scope.project.ProjectId;
                    }
                }
            });

            modalInstance.result.then(function (){//selectedItem) {
                //$scope.selected = selectedItem;
            }, function () {
                console.log('Modal dismissed at: ' + new Date());
            });
        };

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };


    });

angular.module('configuratorApp')
.controller('ModalInstanceCtrl', function ($rootScope,$scope, $compile,$uibModalInstance,ProjectSecurityService, securitystepname,projectId) {

    $scope.loadProjectSecuritySteps= function(){
        ProjectSecurityService.find({securitystepname:securitystepname+"Info",projectId:projectId}, $scope.project, function (test) {

            angular.forEach(test, function(field, key) {
                //alert(field+" "+key);
                if(key!="$promise" && key!="ProjectId" &&key!="$resolved" && key!=securitystepname+"ConfigId")
                var sourceHtml =
                    "<div class=\"form-group\">" +
                    "<label>" + key+ "</label>" +
                        "<input type=\"text\" class=\"form-control\" data-ng-model=\"securitystepinfo." +
                    key + "\">" +
                    "</div>";




                var compiledHtml = $compile(sourceHtml)($scope);
                $('#dynamicForm').append(
                compiledHtml);
            });
            $scope.securitystepinfo=test;
        }, function (error) {
            $rootScope.errorAlert(error)
        });
    };



    $scope.saveSecurityStepProject = function(){
        $scope.securitystepinfo.ProjectId=projectId;
        ProjectSecurityService.update({securitystepname:securitystepname+"Info",projectId:projectId}, $scope.securitystepinfo, function (data) {
            $uibModalInstance.close();

        }, function (error) {
            $scope.saveSecurityStepProjectError=error.data.ExceptionMessage;
            $rootScope.showAlert("alertSaveSecurityStepProjectError");
        });
    };

    $scope.ok = function () {

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.loadProjectSecuritySteps();
});