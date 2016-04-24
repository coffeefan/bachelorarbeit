'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('SecurityStepSurvey', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/SecurityStepSurvey/:typ', {typ:'@typ'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});




