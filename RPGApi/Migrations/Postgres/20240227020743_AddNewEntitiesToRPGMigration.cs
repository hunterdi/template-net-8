using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGApi.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class AddNewEntitiesToRPGMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tagConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CastTo = table.Column<int>(type: "integer", nullable: false, defaultValue: 4),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tagConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "virtualCalculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtualCalculations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    RaceId = table.Column<Guid>(type: "uuid", nullable: false),
                    LifePoints = table.Column<int>(type: "integer", nullable: false),
                    SoulsPoints = table.Column<int>(type: "integer", nullable: false),
                    StaminaPoints = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_characters_races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personalties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personalties_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "souls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_souls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_souls_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RequirementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_actions_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseValue = table.Column<int>(type: "integer", nullable: false),
                    VariableValue = table.Column<int>(type: "integer", nullable: true),
                    ModifiedValue = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonalityId = table.Column<Guid>(type: "uuid", nullable: true),
                    RestrictionId = table.Column<Guid>(type: "uuid", nullable: true),
                    SoulId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attributes_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_attributes_personalties_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "personalties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_attributes_souls_SoulId",
                        column: x => x.SoulId,
                        principalTable: "souls",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "metrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: true),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequirementId = table.Column<Guid>(type: "uuid", nullable: true),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: true),
                    TalentId = table.Column<Guid>(type: "uuid", nullable: true),
                    VirtualCalculationId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_metrics_actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_metrics_attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "attributes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_metrics_virtualCalculations_VirtualCalculationId",
                        column: x => x.VirtualCalculationId,
                        principalTable: "virtualCalculations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetricId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    ReferenceValue = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Origin = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_points_metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restrictions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MetricId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_restrictions_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_restrictions_metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "uuid", nullable: false),
                    MetricId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tags_metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tags_tagConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "tagConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RestrictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requirements_restrictions_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "restrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RequirementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_skills_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_skills_requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "talent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RequirementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_talent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_talent_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_talent_requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actions_CharacterId",
                table: "actions",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_actions_RequirementId",
                table: "actions",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_CharacterId",
                table: "attributes",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_PersonalityId",
                table: "attributes",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_RestrictionId",
                table: "attributes",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_SoulId",
                table: "attributes",
                column: "SoulId");

            migrationBuilder.CreateIndex(
                name: "IX_characters_RaceId",
                table: "characters",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_ActionId",
                table: "metrics",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_AttributeId",
                table: "metrics",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_RequirementId",
                table: "metrics",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_SkillId",
                table: "metrics",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_TalentId",
                table: "metrics",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_metrics_VirtualCalculationId",
                table: "metrics",
                column: "VirtualCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_personalties_CharacterId",
                table: "personalties",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_points_MetricId",
                table: "points",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_requirements_RestrictionId",
                table: "requirements",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_restrictions_CharacterId",
                table: "restrictions",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_restrictions_MetricId",
                table: "restrictions",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_CharacterId",
                table: "skills",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_RequirementId",
                table: "skills",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_souls_CharacterId",
                table: "souls",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_ConfigurationId",
                table: "tags",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_MetricId",
                table: "tags",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_talent_CharacterId",
                table: "talent",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_talent_RequirementId",
                table: "talent",
                column: "RequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_actions_requirements_RequirementId",
                table: "actions",
                column: "RequirementId",
                principalTable: "requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_attributes_restrictions_RestrictionId",
                table: "attributes",
                column: "RestrictionId",
                principalTable: "restrictions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_metrics_requirements_RequirementId",
                table: "metrics",
                column: "RequirementId",
                principalTable: "requirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_metrics_skills_SkillId",
                table: "metrics",
                column: "SkillId",
                principalTable: "skills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_metrics_talent_TalentId",
                table: "metrics",
                column: "TalentId",
                principalTable: "talent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actions_characters_CharacterId",
                table: "actions");

            migrationBuilder.DropForeignKey(
                name: "FK_attributes_characters_CharacterId",
                table: "attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_personalties_characters_CharacterId",
                table: "personalties");

            migrationBuilder.DropForeignKey(
                name: "FK_restrictions_characters_CharacterId",
                table: "restrictions");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_characters_CharacterId",
                table: "skills");

            migrationBuilder.DropForeignKey(
                name: "FK_souls_characters_CharacterId",
                table: "souls");

            migrationBuilder.DropForeignKey(
                name: "FK_talent_characters_CharacterId",
                table: "talent");

            migrationBuilder.DropForeignKey(
                name: "FK_actions_requirements_RequirementId",
                table: "actions");

            migrationBuilder.DropForeignKey(
                name: "FK_metrics_requirements_RequirementId",
                table: "metrics");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_requirements_RequirementId",
                table: "skills");

            migrationBuilder.DropForeignKey(
                name: "FK_talent_requirements_RequirementId",
                table: "talent");

            migrationBuilder.DropForeignKey(
                name: "FK_attributes_personalties_PersonalityId",
                table: "attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_attributes_restrictions_RestrictionId",
                table: "attributes");

            migrationBuilder.DropTable(
                name: "abilities");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "tagConfigurations");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "requirements");

            migrationBuilder.DropTable(
                name: "personalties");

            migrationBuilder.DropTable(
                name: "restrictions");

            migrationBuilder.DropTable(
                name: "metrics");

            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "talent");

            migrationBuilder.DropTable(
                name: "virtualCalculations");

            migrationBuilder.DropTable(
                name: "souls");
        }
    }
}
