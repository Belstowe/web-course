﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCourse.Models;

#nullable disable

namespace MyCourse.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20230512220053_AnswersModel")]
    partial class AnswersModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MyCourse.Models.ChoicesAnswer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Choices")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionRefID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnswerID");

                    b.HasIndex("QuestionRefID");

                    b.ToTable("ChoicesAnswer");
                });

            modelBuilder.Entity("MyCourse.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuizRefID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionID");

                    b.HasIndex("QuizRefID");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyCourse.Models.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuizID");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("MyCourse.Models.VariableAnswer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionRefID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnswerID");

                    b.HasIndex("QuestionRefID");

                    b.ToTable("VariableAnswer");
                });

            modelBuilder.Entity("MyCourse.Models.ChoicesQuestion", b =>
                {
                    b.HasBaseType("MyCourse.Models.Question");

                    b.Property<bool>("AllowMultipleChoices")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Choices")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("ChoicesQuestion");
                });

            modelBuilder.Entity("MyCourse.Models.VariableQuestion", b =>
                {
                    b.HasBaseType("MyCourse.Models.Question");

                    b.Property<string>("Hint")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("VariableQuestion");
                });

            modelBuilder.Entity("MyCourse.Models.ChoicesAnswer", b =>
                {
                    b.HasOne("MyCourse.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("MyCourse.Models.Question", b =>
                {
                    b.HasOne("MyCourse.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("MyCourse.Models.VariableAnswer", b =>
                {
                    b.HasOne("MyCourse.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("MyCourse.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
