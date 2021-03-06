import { TenantResourceUsageDetailComponent } from './components/tenant.components/tenant-resource-usage-detail/tenant-resource-usage-detail.component';
import { TenantPageViewResourceUsageComponent } from './components/tenant.components/tenant-page-view-resource-usage/tenant-page-view-resource-usage.component';
import { ManagerHomeComponent } from './components/manager.components/manager-home/manager-home.component';
/// <reference types="node" />
import { GoogleChartsModule } from 'angular-google-charts';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TenantHomeComponent } from './components/tenant.components/tenant-home/tenant-home.component';
import { MaintenanceRequestsComponent } from './components/universal.components/maintenance-requests/maintenance-requests.component';
import { NavMenuComponent } from './components/universal.components/nav-menu/nav-menu.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { MaintenanceRequestFormComponent } from './components/universal.components/maintenance-request-form/maintenance-request-form.component';
import { ApiTokenInterceptor } from './helpers/api-token.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './components/universal.components/login/login.component';
import { RouterHubComponent } from './components/universal.components/router-hub/router-hub.component';

import { ResourceEnumPipe } from './helpers/resource-enum-pipe';
import { MaintenanceCloseReasonEnumPipe } from './helpers/maintenance-close-reason-pipe';
import { ManagerListTenantsComponent } from './components/manager.components/manager-list-tenants/manager-list-tenants.component';
import { UnauthorizedAccessComponent } from './components/universal.components/unauthorized-access/unauthorized-access.component';
import { TenantPageBillPayComponent } from './components/tenant.components/tenant-page-bill-pay/tenant-page-bill-pay.component';
import { TenantPageListBillsComponent } from './components/tenant.components/tenant-page-list-bills/tenant-page-list-bills.component';
import { TenantPageListAgreementsComponent } from './components/tenant.components/tenant-page-list-agreements/tenant-page-list-agreements.component';
import { TenantEditInfoComponent } from './components/tenant.components/tenant-edit-info/tenant-edit-info.component';
import { AssignLeasePageComponent } from './components/manager.components/manager-assign-lease-page/assign-lease-page.component';
import { ManagerCreateAgreementTempalteComponent } from './components/manager.components/manager-create-agreement-template/manager-create-agreement-template.component';
import { ManagerCreateTenantPageComponent } from './components/manager.components/manager-create-tenant-page/manager-create-tenant-page.component';
import { TenantSignupPageComponent } from './components/tenant.components/tenant-signup-page/tenant-signup-page.component';
import { AppIndexComponent } from './components/universal.components/app-index/app-index.component';
import { LeaseAgreementTextComponent } from './components/universal.components/lease-agreement-text/lease-agreement-text.component';
import { ManagerPageListAgreementsComponent } from './components/manager.components/manager-page-list-agreements/manager-page-list-agreements.component';

@NgModule({
  declarations: [
    AppComponent,

    // Components - Universal
    NavMenuComponent,
    MaintenanceRequestsComponent,
    MaintenanceRequestFormComponent,
    LoginComponent,
    RouterHubComponent,
    UnauthorizedAccessComponent,
    AppIndexComponent,
    LeaseAgreementTextComponent,

    // Tenant components
    TenantHomeComponent,
    TenantDetailsComponent,
    TenantResourceUsageDetailComponent,

    // Tenant pages
    TenantPageListBillsComponent,
    TenantPageListAgreementsComponent,
    TenantPageBillPayComponent,
    TenantEditInfoComponent,
    TenantPageViewResourceUsageComponent,
    TenantSignupPageComponent,

    // Manager components
    ManagerHomeComponent,
    ManagerListTenantsComponent,
    AssignLeasePageComponent,
    ManagerCreateAgreementTempalteComponent,
    ManagerCreateTenantPageComponent,
    ManagerPageListAgreementsComponent,

    // Pipes
    ResourceEnumPipe,
    MaintenanceCloseReasonEnumPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    GoogleChartsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ApiTokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
