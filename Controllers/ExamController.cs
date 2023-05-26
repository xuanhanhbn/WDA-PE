using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WDA_PE.Models;
using WDA_PE.Repositories;

namespace WDA_PE.Controllers;

public class ExamController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IRepository<Exam> _examRepository;
    private readonly IRepository<Classroom> _classroomRepository;
    private readonly IRepository<Subject> _subjectRepository;
    private readonly IRepository<Faculty> _facultyRepository;

    public ExamController(AppDbContext dbContext,
        IRepository<Exam> examRepository,
        IRepository<Classroom> classroomRepository,
        IRepository<Subject> subjectRepository,
        IRepository<Faculty> facultyRepository)
    {
        _dbContext = dbContext;
        _examRepository = examRepository;
        _classroomRepository = classroomRepository;
        _subjectRepository = subjectRepository;
        _facultyRepository = facultyRepository;
    }

    public async Task<IActionResult> Index()
    {
        List<Exam> exams = await _examRepository.Get().ToListAsync();
        ViewBag.exams = exams;
        return View();
    }

    public async Task<IActionResult> Add()
    {
        List<Subject> subjects = await _subjectRepository.Get().ToListAsync();
        List<Classroom> classrooms = await _classroomRepository.Get().ToListAsync();
        List<Faculty> faculties = await _facultyRepository.Get().ToListAsync();
        ViewBag.subjects = subjects;
        ViewBag.classrooms = classrooms;
        ViewBag.faculties = faculties;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Exam exam, Guid subject, Guid classroom, Guid faculty)
    {
        exam.Classroom = await _classroomRepository.GetById(classroom);
        exam.Subject = await _subjectRepository.GetById(subject);
        exam.Faculty = await _facultyRepository.GetById(faculty);
        var res = await _examRepository.Create(exam);
        return RedirectToAction("Index");
    }
}