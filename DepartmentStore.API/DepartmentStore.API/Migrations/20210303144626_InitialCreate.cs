using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartmentStore.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANCH",
                columns: table => new
                {
                    BRANCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CITY = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    STATE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ZIP_CODE = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH", x => x.BRANCH_ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CITY = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CUST_TYPE_CD = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    FED_ID = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    POSTAL_CODE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    STATE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CUSTOMER__93ABC0030EA330E9", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DEPARTME__512A59AC1273C1CD", x => x.DEPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_TYPE",
                columns: table => new
                {
                    PRODUCT_TYPE_CD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCT___A60F3DC925869641", x => x.PRODUCT_TYPE_CD);
                });

            migrationBuilder.CreateTable(
                name: "BUSINESS",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false),
                    INCORP_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    STATE_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BUSINESS__93ABC0030AD2A005", x => x.CUST_ID);
                    table.ForeignKey(
                        name: "BUSINESS_EMPLOYEE_FK",
                        column: x => x.CUST_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INDIVIDUAL",
                columns: table => new
                {
                    CUST_ID = table.Column<int>(type: "int", nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__INDIVIDU__93ABC0031A14E395", x => x.CUST_ID);
                    table.ForeignKey(
                        name: "INDIVIDUAL_CUSTOMER_FK",
                        column: x => x.CUST_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OFFICER",
                columns: table => new
                {
                    OFFICER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    END_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    TITLE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CUST_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFICER", x => x.OFFICER_ID);
                    table.ForeignKey(
                        name: "OFFICER_CUSTOMER_FK",
                        column: x => x.CUST_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    EMP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    END_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIRST_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LAST_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    TITLE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ASSIGNED_BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    DEPT_ID = table.Column<int>(type: "int", nullable: true),
                    SUPERIOR_EMP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EMPLOYEE__16EBFA26164452B1", x => x.EMP_ID);
                    table.ForeignKey(
                        name: "EMPLOYEE_BRANCH_FK",
                        column: x => x.ASSIGNED_BRANCH_ID,
                        principalTable: "BRANCH",
                        principalColumn: "BRANCH_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EMPLOYEE_DEPARTMENT_FK",
                        column: x => x.DEPT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DEPT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EMPLOYEE_EMPLOYEE_FK",
                        column: x => x.SUPERIOR_EMP_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PRODUCT_CD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DATE_OFFERED = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATE_RETIRED = table.Column<DateTime>(type: "datetime", nullable: true),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PRODUCT_TYPE_CD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCT__52B466A421B6055D", x => x.PRODUCT_CD);
                    table.ForeignKey(
                        name: "PRODUCT_PRODUCT_TYPE_FK",
                        column: x => x.PRODUCT_TYPE_CD,
                        principalTable: "PRODUCT_TYPE",
                        principalColumn: "PRODUCT_TYPE_CD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AVAIL_BALANCE = table.Column<double>(type: "float", nullable: true),
                    CLOSE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAST_ACTIVITY_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    PENDING_BALANCE = table.Column<double>(type: "float", nullable: true),
                    STATUS = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CUST_ID = table.Column<int>(type: "int", nullable: true),
                    OPEN_BRANCH_ID = table.Column<int>(type: "int", nullable: false),
                    OPEN_EMP_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_CD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ACCOUNT_ID);
                    table.ForeignKey(
                        name: "ACCOUNT_BRANCH_FK",
                        column: x => x.OPEN_BRANCH_ID,
                        principalTable: "BRANCH",
                        principalColumn: "BRANCH_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ACCOUNT_CUSTOMER_FK",
                        column: x => x.CUST_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ACCOUNT_EMPLOYEE_FK",
                        column: x => x.OPEN_EMP_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ACCOUNT_PRODUCT_FK",
                        column: x => x.PRODUCT_CD,
                        principalTable: "PRODUCT",
                        principalColumn: "PRODUCT_CD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ACC_TRANSACTION",
                columns: table => new
                {
                    TXN_ID = table.Column<decimal>(type: "decimal(19,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNT = table.Column<double>(type: "float", nullable: false),
                    FUNDS_AVAIL_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    TXN_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    TXN_TYPE_CD = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ACCOUNT_ID = table.Column<int>(type: "int", nullable: true),
                    EXECUTION_BRANCH_ID = table.Column<int>(type: "int", nullable: true),
                    TELLER_EMP_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ACC_TRAN__C512E7E203317E3D", x => x.TXN_ID);
                    table.ForeignKey(
                        name: "ACC_TRANSACTION_ACCOUNT_FK",
                        column: x => x.ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ACCOUNT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ACC_TRANSACTION_BRANCH_FK",
                        column: x => x.EXECUTION_BRANCH_ID,
                        principalTable: "BRANCH",
                        principalColumn: "BRANCH_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ACC_TRANSACTION_EMPLOYEE_FK",
                        column: x => x.TELLER_EMP_ID,
                        principalTable: "EMPLOYEE",
                        principalColumn: "EMP_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TRANSACTION_ACCOUNT_ID",
                table: "ACC_TRANSACTION",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TRANSACTION_EXECUTION_BRANCH_ID",
                table: "ACC_TRANSACTION",
                column: "EXECUTION_BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACC_TRANSACTION_TELLER_EMP_ID",
                table: "ACC_TRANSACTION",
                column: "TELLER_EMP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_CUST_ID",
                table: "ACCOUNT",
                column: "CUST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_OPEN_BRANCH_ID",
                table: "ACCOUNT",
                column: "OPEN_BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_OPEN_EMP_ID",
                table: "ACCOUNT",
                column: "OPEN_EMP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_PRODUCT_CD",
                table: "ACCOUNT",
                column: "PRODUCT_CD");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ASSIGNED_BRANCH_ID",
                table: "EMPLOYEE",
                column: "ASSIGNED_BRANCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DEPT_ID",
                table: "EMPLOYEE",
                column: "DEPT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_SUPERIOR_EMP_ID",
                table: "EMPLOYEE",
                column: "SUPERIOR_EMP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFICER_CUST_ID",
                table: "OFFICER",
                column: "CUST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_PRODUCT_TYPE_CD",
                table: "PRODUCT",
                column: "PRODUCT_TYPE_CD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACC_TRANSACTION");

            migrationBuilder.DropTable(
                name: "BUSINESS");

            migrationBuilder.DropTable(
                name: "INDIVIDUAL");

            migrationBuilder.DropTable(
                name: "OFFICER");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "EMPLOYEE");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "BRANCH");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "PRODUCT_TYPE");
        }
    }
}
