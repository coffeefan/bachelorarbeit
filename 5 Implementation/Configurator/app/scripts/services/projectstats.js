'use strict';

/**
 * @ngdoc function
 * @name configuratorApp.service:RegistrationService
 * @description
 * # ForgotPasswordService
 * Service of the configuratorApp
 */


angular.module('configuratorApp').
factory('ProjectStatsLastMonthService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Projects/Stats/LastMonth', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});

angular.module('configuratorApp').
factory('ProjectStatsAuthenticationService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Projects/Stats/AuthenticationStatus', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});

angular.module('configuratorApp').
factory('ProjectStatsValidationTimeService', function($resource,$rootScope,$sessionStorage){
    return $resource($rootScope.ServiceUrl+'api/Projects/Stats/ValidationTime', {id:'@id'}, {
        'find': { method:'Get',isArray:false, headers:{'Authorization':'Bearer ' +$sessionStorage.accessToken}}
    });
});

